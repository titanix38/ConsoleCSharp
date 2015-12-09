$(document).ready(function () {

    $('.thumbnail').mouseenter(function () {
        $(this).css('background-color', '#eeeeee');
    });

    $('.thumbnail').mouseleave(function () {
        $(this).css('background-color', '#ffffff');
    });
});

function toast(msg){
	var options = {
		duration: 1500,
		sticky: false,
		type: 'info',
		
	};
	message = "<h4>"+msg+"</h4>";
	$.toast.config.align = 'right';
	$.toast.config.width = 400;
	$.toast(message, options);
}
