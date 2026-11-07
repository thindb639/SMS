// Chỉ được load ở trang Classes/Index (qua @section Scripts)
$(function () {
    $('.classes-filter select').on('change', function () {
        this.form.submit();
    });

    setTimeout(function () {
        $('.alert-success').fadeOut();
    }, 3000);
});
