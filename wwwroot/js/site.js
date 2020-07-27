/////////////////////////////////////////////













//////////////////////////////////////////////
function moveComments(commentId) {
    //const comment_div = document.getElementById("commentdiv_" + commentId);
    //list_comment_div.removeChild(comment_div);
}

function modifyPostForm(postId) {
    const modifyPost_div = document.getElementById("modifyPostDiv_" + postId);
    modifyPost_div.classList.remove("hidden");
}

function modifyPost(postId) {
    const modifyPostId_input = document.getElementById("modifyPostId_" + postId);
    const modifyPostTitle_input = document.getElementById("modifyPostTitle_" + postId);
    const modifyPostDescription_input = document.getElementById("modifyPostDescription_" + postId);


    var data = new FormData();
    data.append("modifyPostId", modifyPostId_input.value);
    data.append("modifyPostTitle", modifyPostTitle_input.value);
    data.append("modifyPostDescription", modifyPostDescription_input.value);


    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Post/ModifyPost");
    xhr.onloadend = function () {
        var response = this.responseText;
        console.log(response);
        location.reload();
    }
    xhr.send(data);


}

function test(postId) {
    const createComment_form = document.getElementById("createCommentForm_" + postId);
    createComment_form.classList.remove("hidden2");
}

function createPost() {
    const createPost_div = document.getElementById("createpostDiv");
    createPost_div.classList.remove("hidden");
}



function ifComment(commentPostId, commentId, commentUsername, commentMessage, commentDate, postId) {

    if (commentPostId == postId) {
        const divparentcomment = document.createElement("div");
        divparentcomment.id = "parentDivComment";

        // inside divparentcomment 1
        const commentdiv = document.createElement("div");
        commentdiv.id = `commentdiv_${commentId}`;

        // inside commentdiv 2
        const commentH4 = document.createElement("h4");
        commentH4.innerText = `[${commentUsername}] [${commentId}] `;

        const commentP = document.createElement("p");
        commentP.innerText = `${commentMessage} [${commentDate}]`;

        // inside commentH4 3
        const deleteImgComment = document.createElement("img");
        deleteImgComment.src = "~/images/garbage2.png";
        deleteImgComment.onclick = `deleteComment(${commentId})`;

        const modifyImgComment = document.createElement("img");
        modifyImgComment.src = "~/images/newPost.png";
        modifyImgComment.onclick = `modifyComment(${commentId})`;

        // modifycommentForm 
        const modifycommentDiv = document.createElement("div");
        modifycommentDiv.id = `modifyCommentDiv_${commentId}`;
        modifycommentDiv.classList.add("hidden2");

        // inside modifycommentForm 3 
        // ---------------Leave out 4 now -----------------
        const modifycommentidInput = document.createElement("input");
        modifycommentidInput.type = "number";
        modifycommentidInput.name = "commentId";
        modifycommentidInput.value = `${commentId}`;
        modifycommentidInput.hidden = true;

        const modifiedMessageLabel = document.createElement("label");
        modifiedMessageLabel.innerText = "Modified Message:";

        const submitmodifiedcommentInput = document.createElement("input");
        submitmodifiedcommentInput.type = "submit";
        submitmodifiedcommentInput.value = "Modify Comment";
        submitmodifiedcommentInput.onclick = `modifyComment2(${commentId})`;
        // ----------------------------------------------------------------

        const deletecommentInput = document.createElement("input");
        deletecommentInput.type = "number";
        deletecommentInput.name = "commentId";
        deletecommentInput.value = `${commentId}`;
        deletecommentInput.hidden = true;
        deletecommentInput.id = `getCommentId_${commentId}`;


        // REMINDER, appendChild

        commentH4.appendChild(deleteImgComment);
        commentH4.appendChild(modifyImgComment);


        commentdiv.appendChild(deletecommentInput);
        commentdiv.appendChild(commentP);
        commentdiv.appendChild(commentH4);


        divparentcomment.appendChild(commentdiv);

        return divparentcomment;
    }
}


// Needs to be finished
// let's just do create and delete First
function modifyComment2(commentId) {
    //const modifiedcommentMessage = document.getElementById("modifiedcommentMessage");


    //const commentDiv = document.getElementById("commentdiv_" + commentId);

    //var data = new FormData();
    //data.append("message", modifiedcommentMessage.value);
    //data.append("commentId", commentId);



    //var xhr = new XMLHttpRequest();
    //xhr.open("POST", "/Comment/ModifyComment");
    //xhr.onload = function () {
    //    commentDiv.parentElement.removeChild(commentDiv);
    //}

    //xhr.send(data);



}



// Not finished!
function generatePostDOM(postId, postTitle, postDescription, postUsername, postDate) {
    //--------------- parentDivPost 1
    const parentDivPost = document.createElement("div");
    parentDivPost.id = "parentDivPost";

    // inside of (((((parentDivPost))))
    //--------------- postdiv 2
    const postdiv = document.createElement("div");
    postdiv.id = `postdiv_${postId}`;


    // inside of (((((postdiv)))) --- 3
    const headerTwo = document.createElement("h2");
    headerTwo.innerText = `${postTitle} [${postId}]`;

    const garbageImg = document.createElement("img");
    garbageImg.setAttribute("src", "~/images/garbage2.png");
    garbageImg.setAttribute("onclick", `deletePost(${postId})`);

    const hiddenInputPostId = document.createElement("input");
    hiddenInputPostId.id = `postId_${postId}`;
    hiddenInputPostId.type = "number";
    hiddenInputPostId.name = "PostId";
    hiddenInputPostId.value = postId;
    hiddenInputPostId.hidden = true;
    // or 
    // hiddenInputPostId.value = `${postId}`;


    const p = document.createElement("p");
    p.innerText = `${postDescription} by [${postUsername}] ${postDate}`;

    const createpostDiv = document.createElement("div");

    const modifypostImg = document.createElement("img");
    img.setAttribute("src", "~/images/newPost.png");
    img.setAttribute("alt", "ModifyPost");
    img.setAttribute("onclick", `modifyPostForm(${postId})`);

    //------------------------------------------
    const modifyPostDiv = document.createElement("div");
    modifyPostDiv.id = `modifyPostDiv_${postId}`;
    modifyPostDiv.classList.add("hidden");

    // inside modifypostDiv
    const modifyPostIdInput = document.createElement("input");
    modifyPostIdInput.id = `modifyPostId_${postId}`;
    modifyPostIdInput.type = "number";
    modifyPostIdInput.name = "modifyPostId";
    modifyPostIdInput.value = `${postId}`;
    modifyPostIdInput.hidden = true;

    const labelTitle = document.createElement("label");
    labelTitle.innerText = "Title:";

    const labelDescription = document.createElement("label");
    labelDescription.innerText = "Description:";

    const posttitleInput = document.createElement("input");
    posttitleInput.type = "text";
    posttitleInput.name = "modifyPostTitle";
    posttitleInput.id = `modifyPostTitle_${postId}`;

    const postdescriptionInput = document.createElement("input");
    postdescriptionInput.type = "text";
    postdescriptionInput.name = "modifyPostDescription";
    postdescriptionInput.id = `modifyPostDescription_${postId}`;

    const modifypostButton = document.createElement("button");
    modifypostButton.onclick = `modifyPost(${postId})`;
    //-----------------------------------------------

    // COMMENT
    const h3Comments = document.createElement("h3");
    h3Comments.innerText = "Comments:";

    const listcommentsDiv = document.createElement("div");
    listcommentsDiv.id = "list_comments_div";

    //inside of list_comments_div 2
    const newcommentButton = document.createElement("button");
    newcommentButton.onclick = `test(${postId})`;
    newcommentButton.innerText = "Create New Comment";

    // createcommentDiv
    const createcommentDiv = document.createElement("div");
    createcommentDiv.id = `createCommentDiv_${postId}`;
    createcommentDiv.classList.add("hidden2");

    // inside createcommentDiv 3
    const messageLabel = document.createElement("label");
    messageLabel.innerText = "Message:";

    const messageInput = document.createElement("input");
    messageInput.id = "commentmessage";
    messageInput.name = "message";
    messageInput.type = "text";

    const postIdInput = document.createElement("input");
    postIdInput.value = `${postId}`;
    postIdInput.name = "postId";
    postIdInput.type = "number";

    const submitnewcomment = document.createElement("input");
    submitnewcomment.type = "submit";
    submitnewcomment.value = "CreateMessage";
    // ITT TARTOK  ------------------------------
    // Function MISSING
    submitnewcomment.onclick = `createComment()`;

    //-----------------------------------------------

    // appending to modifyPostDiv
    modifyPostDiv.appendChild(modifyPostIdInput);
    modifyPostDiv.appendChild(labelTitle);
    modifyPostDiv.appendChild(labelDescription);
    modifyPostDiv.appendChild(posttitleInput);
    modifyPostDiv.appendChild(postdescriptionInput);
    modifyPostDiv.appendChild(modifypostButton);


    //appending to createpostDiv
    createpostDiv.appendChild(modifypostImg);
    createpostDiv.appendChild(modifyPostDiv);

    //appending to <p>
    p.appendChild(createpostDiv);


    //appending to postDiv


}


// not finished
function createComment(commentId, commentUsername, commentMessage, commentDate) {
    // xhr should be here?



}

function postCreatePost() {
    //const getUsernamePost = document.getElementById("getUsernamePost");

    //DOM - HTML create it here first

    const postContainer = document.getElementById("post_container");



    //Database
    const posttitle_input = document.getElementById("posttitle");
    const postdescription_input = document.getElementById("postdescription");
    var data = new FormData();
    data.append("title", posttitle_input.value);
    data.append("description", postdescription_input.value);



    var xhr = new XMLHttpRequest();
    xhr.addEventListener =
        xhr.open("POST", "/Post/CreatePost");
    xhr.onload = function () {
        var newPost = JSON.parse(this.responseText);

        // a fenti response-bol kell kibogarasznom az post.Id, post.Title, post.Username etc.
        // aztan adjam at ezeket argument-kent a functionba
        //A functionba, amelyikkel letre fogom hozni a DOM-ban levo dolgokat (div, input, ilyesmiket)

        console.log("Newpost:" + newPost);

    };

    xhr.send(data);
}



function deletePost(postId) {
    const postId_input = document.getElementById("postId_" + postId);


    // deleting DIV
    const postDiv = document.getElementById("postdiv_" + postId);


    var data = new FormData();
    data.append("postId", postId_input.value);

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/Post/DeletePost");

    xhr.onload = function () {
        postDiv.parentElement.removeChild(postDiv);
    }

    xhr.send(data);
}

function modifyComment(commentId) {
    const modifyComment_div = document.getElementById("modifyCommentDiv_" + commentId);
    modifyComment_div.classList.remove("hidden2");
}

function deleteComment(commentId) {
    //const commentUsername = document.getElementById("getCommentUsername");
    const commentId_input = document.getElementById("getCommentId_" + commentId);

    // comment div
    const comment_div = document.getElementById("commentdiv_" + commentId);


    var data = new FormData();
    //data.append("username", commentUsername.value);
    data.append("commentId", commentId_input.value);

    var xhr = new XMLHttpRequest();
    xhr.onload = function () {

        comment_div.parentElement.removeChild(comment_div);
    }
    xhr.open("POST", "/Comment/DeleteComment");

    xhr.send(data);
}

//////////////////////////////////////////////////////////////////////////////////




function getAllComments() {
    var xhr = new XMLHttpRequest();
    xhr.open('GET', "/CommentAPI/GetAllComments");
    xhr.onload = function () {
        console.log(xhr.responseText);

        var comments = JSON.parse(xhr.responseText);
        return comments;

    };
    xhr.send();
}

function getAllPosts() {
   
}

function foreach(allPosts, allComments) {

    var once = false;

    for (let i = 0; i < allPosts.length; i++) {
        const post = allPosts[i];

        for (let j = 0; j < allComments.length; j++) {
            const comment = allComments[j];

            if (once == false) {
                ifComment(comment.Post_Id, comment.Id, comment.commentUsername, comment.commentMessage, comment.commentDate, post.Id);
            }
            if (comment.Post_Id == post.Id) {

            }
        }
    }
}

function function1(posts) {
    var htmlString = "";

    for (var i = 0; i < posts.length; i++) {
        htmlString += `<p> Title: ${posts[i].postTitle}</p>`;
    }

    return htmlString;
}
/// Start

window.onload = function () {

    var xhr = new XMLHttpRequest();
    xhr.open('GET', "/PostAPI/GetAllPost");
    xhr.onload = function () {
        console.log(xhr.responseText);

        var allPosts = JSON.parse(xhr.responseText);

        function1(allPosts);

        console.log("done!");

    };
    xhr.send();


}
