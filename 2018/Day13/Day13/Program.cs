using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Threading;


public enum CartDirection {
    Left,
    Right,
    Up,
    Down
}

public class Cart {
    public Cart(int positionX, int positionY, CartDirection direction) {
        PositionX     = positionX;
        PositionY     = positionY;
        Direction     = direction;
        LastDirection = direction;
        Id            = _idCounter;
        _idCounter++;
    }

    private static int           _idCounter;
    public         int           Id;
    public         int           PositionX;
    public         int           PositionY;
    public         CartDirection Direction;
    public         CartDirection LastDirection;

    public int Cross;

    public string DirectionSymbol() {
        if (Direction == CartDirection.Right) return ">";
        if (Direction == CartDirection.Left) return "<";
        if (Direction == CartDirection.Up) return "^";
        if (Direction == CartDirection.Down) return "v";
        return "Warning something is wrong.";
    }

    public string DirectionSymbolRoad() {
        if (Direction == CartDirection.Right) return "-";
        if (Direction == CartDirection.Left) return "-";
        if (Direction == CartDirection.Up) return "|";
        if (Direction == CartDirection.Down) return "|";
        return "Warning something is wrong.";
    }

    public void ApplyDirection() {
        if (Direction == CartDirection.Right) PositionX++;
        else if (Direction == CartDirection.Left) PositionX--;
        else if (Direction == CartDirection.Up) PositionY--;
        else if (Direction == CartDirection.Down) PositionY++;
    }
}


namespace Day13 {
    internal class Program {
        public static void Main(string[] args) {
            var map  = MultipleLineFileInto2DArray("input.txt");
            var road = MultipleLineFileInto2DArray("input.txt");

            var carts = InitializeCarts(ref map);

            var result = "";
            while (result == "") {
                carts.Sort(SortCarts);
                result = MoveCartsOneTick(carts, map, ref road);
            }

            Console.WriteLine(result);
        }

        private static List<Cart> InitializeCarts(ref List<List<string>> input) {
            var carts = new List<Cart>();
            for (var y = 0; y < input.Count; y++) {
                var line = input[y];
                for (var x = 0; x < line.Count; x++) {
                    if (line[x] == ">") {
                        line[x] = "-";

                        var cart = new Cart(x, y, CartDirection.Right);
                        carts.Add(cart);
                    }
                    else if (line[x] == "<") {
                        line[x] = "-";

                        var cart = new Cart(x, y, CartDirection.Left);
                        carts.Add(cart);
                    }
                    else if (line[x] == "^") {
                        line[x] = "|";

                        var cart = new Cart(x, y, CartDirection.Up);
                        carts.Add(cart);
                    }
                    else if (line[x] == "v") {
                        line[x] = "|";

                        var cart = new Cart(x, y, CartDirection.Down);
                        carts.Add(cart);
                    }
                }
            }

            return carts;
        }
        
        

        private static string MoveCartsOneTick(List<Cart> carts, List<List<string>> map, ref List<List<string>> road) {
            road = Clone2DList(map);
            foreach (var cart in carts) {
                if (CheckCrashSymbol(road[cart.PositionY][cart.PositionX]))
                    return cart.PositionX + ", " + cart.PositionY;

                cart.ApplyDirection();
                CalculateNewDirection(road[cart.PositionY][cart.PositionX], cart);

                if (CheckCrashSymbol(road[cart.PositionY][cart.PositionX]))
                    return cart.PositionX + ", " + cart.PositionY;

                road[cart.PositionY][cart.PositionX] = cart.DirectionSymbol();
            }

            return "";
        }

        private static string MoveCartsOneTickRemoveCarts(ref List<Cart>         carts, List<List<string>> map,
            ref                                               List<List<string>> road) {
            road = Clone2DList(map);
            var indexs = new List<Cart>();
            foreach (var cart in carts) {
                if (CheckCrashSymbol(road[cart.PositionY][cart.PositionX])) {
                    indexs.Add(cart);
                    int index = carts.FindIndex(
                        cartt => cart.PositionX == cartt.PositionX && cart.PositionY == cartt.PositionY);
                    indexs.Add(carts[index]);
                }

                cart.ApplyDirection();
                CalculateNewDirection(road[cart.PositionY][cart.PositionX], cart);

                if (CheckCrashSymbol(road[cart.PositionY][cart.PositionX])) {
                    indexs.Add(cart);
                    int index = carts.FindIndex(
                        cartt => cart.PositionX == cartt.PositionX && cart.PositionY == cartt.PositionY);
                    indexs.Add(carts[index]);
                }

                road[cart.PositionY][cart.PositionX] = cart.DirectionSymbol();
            }

            foreach (var i in indexs) {
                var index = carts.FindIndex(cart => cart.Id == i.Id);
                carts.RemoveAt(index);
                road[i.PositionY][i.PositionX] = i.DirectionSymbolRoad();
            }

            if (carts.Count == 1)
                return carts[0].PositionX + ", " + carts[0].PositionY;

            return "";
        }

        private static int RemoveCarts(List<Cart> carts, Cart cartt) {
            int index = carts.FindIndex(cart => cart.PositionX == cartt.PositionX && cart.PositionY == cartt.PositionY);
            return index;
        }

        private static bool CheckCrashSymbol(string symbol) {
            if (symbol == ">" || symbol == "<" || symbol == "^" || symbol == "v")
                return true;
            return false;
        }

        private static void CalculateNewDirection(string roadSymbol, Cart cart) {
            if (roadSymbol == "+") {
                if (cart.LastDirection == CartDirection.Left) {
                    if (cart.Cross == 0) cart.Direction = CartDirection.Down;
                    if (cart.Cross == 2) cart.Direction = CartDirection.Up;
                }
                else if (cart.LastDirection == CartDirection.Right) {
                    if (cart.Cross == 0) cart.Direction = CartDirection.Up;
                    if (cart.Cross == 2) cart.Direction = CartDirection.Down;
                }
                else if (cart.LastDirection == CartDirection.Up) {
                    if (cart.Cross == 0) cart.Direction = CartDirection.Left;
                    if (cart.Cross == 2) cart.Direction = CartDirection.Right;
                }
                else if (cart.LastDirection == CartDirection.Down) {
                    if (cart.Cross == 0) cart.Direction = CartDirection.Right;
                    if (cart.Cross == 2) cart.Direction = CartDirection.Left;
                }

                cart.Cross++;
                if (cart.Cross > 2) cart.Cross = 0;
            }
            else {
                if (cart.LastDirection == CartDirection.Left) {
                    if (roadSymbol == "\\") cart.Direction = CartDirection.Up;
                    if (roadSymbol == "/") cart.Direction  = CartDirection.Down;
                }
                else if (cart.LastDirection == CartDirection.Right) {
                    if (roadSymbol == "\\") cart.Direction = CartDirection.Down;
                    if (roadSymbol == "/") cart.Direction  = CartDirection.Up;
                }
                else if (cart.LastDirection == CartDirection.Up) {
                    if (roadSymbol == "\\") cart.Direction = CartDirection.Left;
                    if (roadSymbol == "/") cart.Direction  = CartDirection.Right;
                }
                else if (cart.LastDirection == CartDirection.Down) {
                    if (roadSymbol == "\\") cart.Direction = CartDirection.Right;
                    if (roadSymbol == "/") cart.Direction  = CartDirection.Left;
                }
            }

            cart.LastDirection = cart.Direction;
        }

        private static int SortCarts(Cart a, Cart b) {
            if (a.PositionY < b.PositionY) return -1;
            if (a.PositionY == b.PositionY) return a.PositionX < b.PositionX ? -1 : 1;
            return 1;
        }

        private static List<List<T>> Clone2DList<T>(List<List<T>> listToClone) {
            var clone = new List<List<T>>();

            foreach (var line in listToClone) {
                var clonedLine = new List<T>();
                foreach (var c in line) {
                    clonedLine.Add(c);
                }

                clone.Add(clonedLine);
            }

            return clone;
        }

        private static List<List<string>> MultipleLineFileInto2DArray(string path) {
            var firstArray = ReadFileLineByLine(path);

            var _2DArray = new List<List<string>>();

            foreach (var line in firstArray) {
                var lineArray = new List<string>();
                foreach (var c in line)
                    lineArray.Add(c.ToString());
                _2DArray.Add(lineArray);
            }

            return _2DArray;
        }

        private static List<string> ReadFileLineByLine(string path) {
            var array = new List<string>();
            var file  = new StreamReader(path);
            for (var i = 0; i < File.ReadLines(path).Count(); i++) {
                var line = file.ReadLine();
                array.Add(line);
            }

            file.Close();
            return array;
        }

        private static void ConsoleWrite2DArray<T>(List<List<T>> _2DArray) {
            var i = 0;
            foreach (var line in _2DArray) {
                Console.Write(i + ": ");
                foreach (var c in line) {
                    Console.Write(c.ToString());
                }

                Console.Write("\n");
                i++;
            }
        }
    }
}