/*
  Author:    Joshua Lipio
  Date:      10/18/2019
  Course:    CS 4540, University of Utah, School of Computing
  Copyright: CS 4540 and Joshua Lipio - This work may not be copied for use in Academic Coursework.

  I, Joshua Lipio, certify that I wrote this code from scratch and did not copy it in part or whole from
  another source.  Any references used in the completion of the assignment are cited in my README file.
*/


//Handle changes for role changing
function handleChange(checkboxId, userName, roleName) {
    //Whenever change is made, bring up dialogue
    Swal.fire({
        title: 'Are you sure?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Confirm'
    }).then((result) => {
        //if confirmed
        if (result.value) {
            //change role
            $.ajax({
                method: "POST",
                url: "/Home/ChangeRole",
                data: {
                    userName: userName,
                    roleName: roleName,
                    addRemove: $("#" + checkboxId).is(":checked")
                }
            }).done(function () {
                //when done, show success dialogue
                Swal.fire(
                    'Role Changed', '',
                    'success'
                )
            }).fail(function () {
                //if fail, show failure dialogue (comes up when removing only admin)
                Swal.fire({
                    type: 'error',
                    title: 'Oops...',
                    text: 'Something went wrong!',
                })
                //set checkbox back since it failed
                $("#" + checkboxId).prop("checked", !$("#" + checkboxId).is(":checked"));
            })
        }
        //set checkbox back since button canceled
        else {
            $("#" + checkboxId).prop("checked", !$("#" + checkboxId).is(":checked"));
        }
       
    })
}