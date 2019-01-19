let InitializeInputs = [];

class Korak{
  constructor(ime, pogoj){
    this.ime = ime;
    this.pogoji = [];
    if(pogoj != "") this.pogoji.push(pogoj);
  }
}

function ReadInput(input){
  for(let i=0; i<input.length; i++){
    let condition = input[i];

    if(CheckIfExists(condition[0]) < 0) InitializeInputs.push(new Korak(condition[0], ""));

    let index = CheckIfExists(condition[1]);
    if(index < 0) InitializeInputs.push(new Korak(condition[1], condition[0]));
    else InitializeInputs[index].pogoji.push(condition[0]);
  }
}

function CheckIfExists(element){
  for(let i=0; i<InitializeInputs.length; i++){
    if(InitializeInputs[i].ime == element) return i;
  }
  return -1;
}
function Sort(){
  InitializeInputs.sort(function(a, b) {
    return a.pogoji.length - b.pogoji.length;
  });

  let groups = GetGroups();
  let joinedGroups = [];
  for(let i=0; i<groups.length; i++){
    groups[i].sort(SortByGroups);
    joinedGroups = joinedGroups.concat(groups[i]);
  }
  InitializeInputs = joinedGroups;
}
function GetGroups(){
  let groups = [];
  let lastNumber = 0;
  let lastIndex = 0;
  let newNumber = 0;
  for(let i=0; i<InitializeInputs.length; i++){
    newNumber = InitializeInputs[i].pogoji.length;
    if(newNumber != lastNumber || i == InitializeInputs.length - 1) {
      if(i == InitializeInputs.length - 1 && newNumber == lastNumber){
        groups.push(InitializeInputs.slice(lastIndex));
      }
      else if(i == InitializeInputs.length - 1 && newNumber != lastNumber){
        groups.push(InitializeInputs.slice(lastIndex, i));
        groups.push(InitializeInputs.slice(i))
      } else{
        groups.push(InitializeInputs.slice(lastIndex, i));
        lastNumber = newNumber;
        lastIndex = i;
      }
    }
  }
  return groups;
}
function SortByGroups(a, b){
    if(a.ime < b.ime) return -1;
    if(a.ime > b.ime) return 1;
    return 0;
}

ReadInput(inputMihael);
Sort();
console.log(InitializeInputs.slice(0));

let result = "";
let loopCount = InitializeInputs.length;
for(let i=0; i<loopCount; i++){
  result += InitializeInputs[0].ime;
  InitializeInputs = InitializeInputs.slice(1);
  RemoveCondition(result[result.length-1]);
  Sort();
}

function RemoveCondition(condition){
  for(let i=0; i<InitializeInputs.length; i++){
    let index = InitializeInputs[i].pogoji.indexOf(condition);
    if(index > -1) InitializeInputs[i].pogoji.splice(index, 1);
  }
}

console.log(result);
