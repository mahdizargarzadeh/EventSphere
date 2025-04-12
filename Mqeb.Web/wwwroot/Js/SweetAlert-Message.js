function ShowMessage(title, textMessage, theme) {
    Swal.fire({
        title: title,
        text: textMessage,
        icon: theme,
        confirmButtonText: "OK"
    });
}