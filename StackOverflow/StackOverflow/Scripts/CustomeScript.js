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