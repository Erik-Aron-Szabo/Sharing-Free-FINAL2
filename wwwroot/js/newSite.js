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




// Gergo segitett
//function generatePostDOM2() {

//    var allPosts = JSON.parse(this.responseText);
//    console.log(allPosts);
    

//    allPosts.forEach(post => {

        



//        //--------------- parentDivPost 1
        


//        // inside of (((((postdiv)))) --- 3
//        const headerTwo = document.createElement("h2");
//        headerTwo.innerText = `${postTitle} [${postId}]`;

//        const garbageImg = document.createElement("img");
//        garbageImg.setAttribute("src", "~/images/garbage2.png");
//        garbageImg.setAttribute("onclick", `deletePost(${postId})`);

//        const hiddenInputPostId = document.createElement("input");
//        hiddenInputPostId.id = `postId_${postId}`;
//        hiddenInputPostId.type = "number";
//        hiddenInputPostId.name = "PostId";
//        hiddenInputPostId.value = postId;
//        hiddenInputPostId.hidden = true;
//        // or 
//        // hiddenInputPostId.value = `${postId}`;


//        const p = document.createElement("p");
//        p.innerText = `${postDescription} by [${postUsername}] ${postDate}`;

//        const createpostDiv = document.createElement("div");

//        const modifypostImg = document.createElement("img");
//        modifypostImg.setAttribute("src", "~/images/newPost.png");
//        modifypostImg.setAttribute("alt", "ModifyPost");
//        modifypostImg.setAttribute("onclick", `modifyPostForm(${postId})`);

//        //------------------------------------------
//        const modifyPostDiv = document.createElement("div");
//        modifyPostDiv.id = `modifyPostDiv_${postId}`;
//        modifyPostDiv.classList.add("hidden");

//        // inside modifypostDiv
//        const modifyPostIdInput = document.createElement("input");
//        modifyPostIdInput.id = `modifyPostId_${postId}`;
//        modifyPostIdInput.type = "number";
//        modifyPostIdInput.name = "modifyPostId";
//        modifyPostIdInput.value = `${postId}`;
//        modifyPostIdInput.hidden = true;

//        const labelTitle = document.createElement("label");
//        labelTitle.innerText = "Title:";

//        const labelDescription = document.createElement("label");
//        labelDescription.innerText = "Description:";

//        const posttitleInput = document.createElement("input");
//        posttitleInput.type = "text";
//        posttitleInput.name = "modifyPostTitle";
//        posttitleInput.id = `modifyPostTitle_${postId}`;

//        const postdescriptionInput = document.createElement("input");
//        postdescriptionInput.type = "text";
//        postdescriptionInput.name = "modifyPostDescription";
//        postdescriptionInput.id = `modifyPostDescription_${postId}`;

//        const modifypostButton = document.createElement("button");
//        modifypostButton.onclick = `modifyPost(${postId})`;
//        //-----------------------------------------------

//        // COMMENT
//        const h3Comments = document.createElement("h3");
//        h3Comments.innerText = "Comments:";

//        const listcommentsDiv = document.createElement("div");
//        listcommentsDiv.id = "list_comments_div";

//        //inside of list_comments_div 2
//        const newcommentButton = document.createElement("button");
//        newcommentButton.onclick = `test(${postId})`;
//        newcommentButton.innerText = "Create New Comment";

//        // createcommentDiv
//        const createcommentDiv = document.createElement("div");
//        createcommentDiv.id = `createCommentDiv_${postId}`;
//        createcommentDiv.classList.add("hidden2");

//        // inside createcommentDiv 3
//        const messageLabel = document.createElement("label");
//        messageLabel.innerText = "Message:";

//        const messageInput = document.createElement("input");
//        messageInput.id = "commentmessage";
//        messageInput.name = "message";
//        messageInput.type = "text";

//        const postIdInput = document.createElement("input");
//        postIdInput.value = `${postId}`;
//        postIdInput.name = "postId";
//        postIdInput.type = "number";

//        const submitnewcomment = document.createElement("input");
//        submitnewcomment.type = "submit";
//        submitnewcomment.value = "CreateMessage";
//        submitnewcomment.addEventListener('click', createComment);

//        //-----------------------------------------------

//        // appending to modifyPostDiv
//        modifyPostDiv.appendChild(modifyPostIdInput);
//        modifyPostDiv.appendChild(labelTitle);
//        modifyPostDiv.appendChild(labelDescription);
//        modifyPostDiv.appendChild(posttitleInput);
//        modifyPostDiv.appendChild(postdescriptionInput);
//        modifyPostDiv.appendChild(modifypostButton);


//        //appending to createpostDiv
//        createpostDiv.appendChild(modifypostImg);
//        createpostDiv.appendChild(modifyPostDiv);

//        //appending to <p>
//        p.appendChild(createpostDiv);


//        //appending to postDiv
//        postdiv.appendChild(p);

//        parentDivPost.appendChild(postdiv);

//        postli.appendChild(parentDivPost);


//    });

//}

// delete post
function deletePost() {

    var postId = parseInt(this.dataset.postId);


    // deleting DIV
    const postli = document.getElementById("postli_" + postId);
    const parentPostDiv = document.getElementById("parentDivPost");


    var xhr = new XMLHttpRequest();
    var url = `/Post/DeletePost/${postId}`;
    xhr.open("POST", url);
    xhr.onload = function () {

        postli.parentElement.removeChild(postli);
    }
    xhr.send();
}

function postCreatePost2() {
    //const getUsernamePost = document.getElementById("getUsernamePost");
    const postContainer = document.getElementById("post_container");

    //Database
    const posttitle_input = document.getElementById("posttitle");
    const postdescription_input = document.getElementById("postdescription");
    var data = new FormData();
    data.append("title", posttitle_input.value);
    data.append("description", postdescription_input.value);

    var xhr = new XMLHttpRequest();
    
    xhr.open("POST", "/Post/CreatePost");
    xhr.addEventListener('click', );
    xhr.onload = function () {
        var newPost = JSON.parse(this.responseText);

        // a fenti response-bol kell kibogarasznom az post.Id, post.Title, post.Username etc.
        // aztan adjam at ezeket argument-kent a functionba
        //A functionba, amelyikkel letre fogom hozni a DOM-ban levo dolgokat (div, input, ilyesmiket)
        const postul = document.querySelector('ul');
        const postcontainer = document.getElementById("post_container");

        newPost.forEach(post => {
            

            //postli
            appendingPostul(post, postul);
            
        });
        postcontainer.appendChild(postul);
    };

    xhr.send(data);
}

//function deletePostList() {
//    //$("div#post_container").remove();

//    const postcontainer = document.getElementById("post_container");
//    while (postcontainer.firstChild) {
//        postcontainer.firstChild.remove();
//    }

//    console.log("delete done");
//}

function appendingPostul(post, postul) {

    var postId = post.id;
    var postTitle = post.title;
    var postDate = post.date;
    var postUsername = post.username;
    var postDescription = post.description;


    const postli = document.createElement("li");
    postli.id = `postli_${postId}`;


    // -----------------1
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
    garbageImg.src = "~/images/garbage2.png";
    garbageImg.addEventListener("click", deletePost);
    garbageImg.dataset.postId = postId;

    const hiddenInputPostId = document.createElement("input");
    hiddenInputPostId.id = `postId_${postId}`;
    hiddenInputPostId.type = "number";
    hiddenInputPostId.name = "PostId";
    hiddenInputPostId.value = postId;
    hiddenInputPostId.hidden = true;

    // ----- <p>
    const p = document.createElement("p");
    p.innerText = `${postDescription} by [${postUsername}] ${postDate}`;

    //inside postdiv
    postdiv.appendChild(headerTwo);
    postdiv.appendChild(garbageImg);
    postdiv.appendChild(hiddenInputPostId);
    postdiv.appendChild(p);

    //inside parentdivpost
    parentDivPost.appendChild(postdiv);

    // inside postli
    postli.appendChild(parentDivPost);

    //add postli to postol
    postul.appendChild(postli);

    const postcontainer = document.getElementById("post_container");
    postcontainer.appendChild(postul);

}


function createPostFormDOM() {

    const titleInput = document.createElement("input");
    titleInput.type = "text";
    titleInput.name = "title";
    titleInput.id = "posttitle";

    const descriptionInput = document.createElement("input");
    descriptionInput.type = "text";
    descriptionInput.name = "description";
    descriptionInput.id = "postdescription";

    const descriptionLabel = document.createElement("label");
    descriptionLabel.innerText = "Description:";

    const titleLabel = document.createElement("label");
    titleLabel.innerText = "Title:";

    const creaptedostDiv = document.createElement("div");
    creaptedostDiv.id = "createpostDiv";

    const sumbitButton = document.createElement("button");
    sumbitButton.innerText = "Create Post";
    sumbitButton.onclick = function () {
        var data = new FormData();
        data.append("title", titleInput.value);
        data.append("description", descriptionInput.value);

        var xhr = new XMLHttpRequest();
        xhr.open('POST', "/Post/CreatePost");
        xhr.onload = function () {
            //deletePostList();
            //onload();
            var newPost = JSON.parse(this.responseText);
            const postUl = document.querySelector("ul");
            appendingPostul(newPost, postUl);
        };
        xhr.send(data);
    };

    creaptedostDiv.appendChild(titleLabel);
    creaptedostDiv.appendChild(titleInput);
    creaptedostDiv.appendChild(descriptionLabel);
    creaptedostDiv.appendChild(descriptionInput); 
    creaptedostDiv.appendChild(sumbitButton);

    const createpostDivParent = document.getElementById("createpost");
    createpostDivParent.appendChild(creaptedostDiv);
}


function CreatePostonLoad() {

    var xhr = new XMLHttpRequest();
    xhr.addEventListener('load', createPostFormDOM);
    xhr.open("GET", "/Post/CreatePost");
    xhr.send();
}



function postList() {
    const postul = document.createElement('ul');
    const postcontainer = document.getElementById("post_container");
    var allposts = JSON.parse(this.responseText);

    allposts.forEach(post => {
        var postId = post.id;
        var postTitle = post.title;
        var postDate = post.date;
        var postUsername = post.username;
        var postDescription = post.description;

        //postli
        const postli = document.createElement("li");
        postli.id = `postli_${postId}`;


        // -----------------1
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
        garbageImg.src = "~/images/garbage2.png";
        garbageImg.addEventListener("click", deletePost);
        garbageImg.dataset.postId = postId;

        const hiddenInputPostId = document.createElement("input");
        hiddenInputPostId.id = `postId_${postId}`;
        hiddenInputPostId.type = "number";
        hiddenInputPostId.name = "PostId";
        hiddenInputPostId.value = postId;
        hiddenInputPostId.hidden = true;


        // ----- <p>
        const p = document.createElement("p");
        p.innerText = `${postDescription} by [${postUsername}] ${postDate}`;

        //inside postdiv
        postdiv.appendChild(headerTwo);
        postdiv.appendChild(garbageImg);
        postdiv.appendChild(hiddenInputPostId);
        postdiv.appendChild(p);

        //inside parentdivpost
        parentDivPost.appendChild(postdiv);

        // inside postli
        postli.appendChild(parentDivPost);


        //add postli to postol
        postul.appendChild(postli);

    });


    postcontainer.appendChild(postul);
}




function onload() {

    var xhr = new XMLHttpRequest();
    // refreshing page works
    xhr.addEventListener('load', postList);
    xhr.open('GET', "/PostAPI/GetAllPost");
    xhr.send();

}

/// Start
onload();
CreatePostonLoad();

