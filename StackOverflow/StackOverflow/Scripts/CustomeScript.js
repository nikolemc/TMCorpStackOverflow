let upVote = (commentId) => {
    let _data = {
        id: commentId,
        voteValue: 1
    };

    if (!commentId) {
        alert("No Post Found");
    }
    else {
        $.ajax({
            url: "/CommentVotes/Vote",
            data: JSON.stringify(_data),
            contentType: "application/json",
            type: "POST",
            dataType: "html",
            success: (newHtml) => {
                $("#VoteCountDisplay-" + commentId).html(newHtml);
            },
            error: (jqXHR, textStatus, errorThrown) => {

            }
        })
    }
}

let downVote = (commentId) => {
    let _data = {
        id: commentId,
        voteValue: -1
    }

    if (!commentId) {
        alert("No Post Found");
    }
    else {
        $.ajax({
            url: "/CommentVotes/Vote",
            data: JSON.stringify(_data),
            contentType: "application/json",
            type: "POST",
            dataType: "html",
            success: (newHtml) => {
                $("#VoteCountDisplay-" + commentId).html(newHtml);
            },
            error: (jqXHR, textStatus, errorThrown) => {

            }
        })
    }
}

let upPost = (postId) => {
   let _data = {
       id: postId,
       voteValue: 1
   }

   if (!postId) {
       alert("No Post Found");
   }
   else {
       $.ajax({
           url: "/PostVotes/Vote",
           data: JSON.stringify(_data),
           contentType: "application/json",
           type: "POST",
           dataType: "html",
           success: (newHtml) => {
               $("#voteContainer-" + postId).html(newHtml);
           },
           error: (jqXHR, textStatus, errorThrown) => {

           }
       })
   }
}


let markAsAnswered = (commentId) => {
    let _data = {
        id: commentId
    };

    if (!commentId) {
        alert("No Post Found");
    }
    else {
        $.ajax({
            url: "/Comments/MarkAnswered",
            data: JSON.stringify(_data),
            contentType: "application/json",
            type: "POST",
            dataType: "html",
            success: (newHtml) => {
                $("#MarkAnsweredDisplay-" + commentId).html(newHtml);
            },
            error: (jqXHR, textStatus, errorThrown) => {

            }
        })
    }
}



let downPost = (postId) => {
    let _data = {
        id: postId,
        voteValue: -1
    }

    if (!postId) {
        alert("No Post Found");
    }
    else {
        $.ajax({
            url: "/PostVotes/Vote",
            data: JSON.stringify(_data),
            contentType: "application/json",
            type: "POST",
            dataType: "html",
            success: (newHtml) => {
                $("#voteContainer-" + postId).html(newHtml);
            },
            error: (jqXHR, textStatus, errorThrown) => {

            }
        })
    }
}
