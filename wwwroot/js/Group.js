const myGroups_p = document.getElementsByClassName("myGroups");
const availableGroups_p = document.getElementsByClassName("availableGroups");

//const groupId_input = document.getElementById("groupId");
//const userId_input = document.getElementById("userId");

const userIdLeave_input = document.getElementById("userIdLeave");
//
const ParentDivMyGroups = document.getElementById("myGroups_div");
const parentDivAvailableGroups = document.getElementById("parentDivAvailableGroups"); 
//

// from MyGroup ---> available
function moveGroups(groupId) {


    const mygroupdiv = document.getElementById("mygroupdiv_" + groupId);

    const mygroupButton = document.getElementById("mygroupButton_" + groupId);

    mygroupButton.innerText = "Join Group";
    //mygroupButton.setAttribute("onclick", "joinGroup(" + groupId + ")");
    mygroupButton.onclick = function () { joinGroup(groupId); };

    // delete, create new button

    mygroupdiv.parentElement.removeChild(mygroupdiv);
    parentDivAvailableGroups.appendChild(mygroupdiv);
}
    

    

// From available ---> MyGroup
function moveGroupsReversed(groupId) {

    const availablegroups_div = document.getElementById("availablegroupsdiv_" + groupId);
    const availablegroupButton = document.getElementById("availablegroupButton_" + groupId);

    availablegroupButton.innerText = "Leave Group";
    availablegroupButton.onclick = function () { leaveGroup(groupId); };
    //availablegroupButton.onclick = "leaveGroup(" + groupId + ")";
    //availablegroupButton.setAttribute("onclick", "leaveGroup(" + groupId + ")");

    availablegroups_div.parentElement.removeChild(availablegroups_div);
    ParentDivMyGroups.appendChild(availablegroups_div);
    

}

function leaveGroup(groupId) {
    const groupIdLeave_input = document.getElementById("groupIdLeave_" + groupId);


    const availableGroups = document.getElementById("availablegroupsdiv_" + groupId);

    var data = new FormData();
    data.append("groupIdLeave", groupIdLeave_input.value);
    data.append("userIdLeave", userIdLeave_input.value);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Group/LeaveGroup");
    xhr.onload = function () {

        if (xhr.status == 200) {
            console.log("Status: " + xhr.status)
            moveGroups(groupId);
        } else {
            alert("Please try again (Error message)");
        }
    }
    xhr.send(data);

}



function joinGroup(groupId) {
    const groupId_input = document.getElementById("groupId_" + groupId);
    const userId_input = document.getElementById("userId");

    var data = new FormData();
    data.append("groupId", groupId_input.value);
    data.append("userId", userId_input.value);

    var xhr = new XMLHttpRequest();
    xhr.onload = function () {
        if (xhr.status == 200) {
            moveGroupsReversed(groupId);
        }
    };
    xhr.open("POST", "/Group/JoinGroup");
    xhr.send(data);
}