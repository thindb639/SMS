// Chỉ được load ở trang Classes/Index (qua @section Scripts)
$(function () {
    $('.classes-filter select').on('change', function () {
        this.form.submit();
    });

    $('.class-delete-form').on('submit', function (e) {
        var code = $(this).data('class-code');
        if (!confirm('Bạn có chắc muốn xóa lớp ' + code + '?')) {
            e.preventDefault();
        }
    });

    setTimeout(function () {
        $('.alert-success').fadeOut();
    }, 3000);
});
