/*
  Author:    Joshua Lipio
  Date:      10/18/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/

//Handle changes for notes
function submitNote(e, noteID, url) {
    e.preventDefault();
    $.ajax({
        //Goes into different controller depending if changing LO or Course note
        url: "/"+url+"/ChangeNote",
        data:
        {
            note: $("#note" + noteID + url).val(),
            noteID: noteID
        },
        method: e.srcElement.method
    })
    .done(function (result) {
        Swal.fire({
            position: 'top-end',
            type: 'success',
            title: 'Note has been saved',
            showConfirmButton: false,
            timer: 1500
        })

    }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log("failed: ");
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);

    })
}