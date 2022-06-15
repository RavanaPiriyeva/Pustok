$(document).ready(function () {
  
    $(".show-detail").click(function (e) {

        console.log("salam")
       
        let url = $(this).attr("href");
      


        $("#bookDetailModal").modal('show');
    })
})