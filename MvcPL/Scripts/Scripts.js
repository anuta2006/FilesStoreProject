(function () {
    $('#form').ajaxForm({
        complete: function (xhr) {
            if (xhr.responseText.length === 0)
                alert("Файл для загрузки не выбран!");
            else
                $('#files').append(xhr.responseText);
            $('#form').clearForm();
        }
    });

    //---------------------------------------------------

    $('body').on("click", '.edit', function (e) {
        var elem = $(this).next();
        $(elem).slideToggle("slow");
    });
})();