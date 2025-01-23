const Common = (() => {
    const renderError = (selector, message) => {
        $(selector).html(`<p>${message}</p>`);
    };

    const showLoading = (selector) => {
        $(selector).html('<p>Loading...</p>');
    };

    const hideLoading = (selector) => {
        $(selector).empty();
    };
    const isValidUser = (user) => {
        if (!user.Username || !user.FullName || !user.Email) {
            return { success: false, message: 'All fields are required.' };
        }
        if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(user.Email)) {
            return { success: false, message: 'Invalid email address.' };
        }
        return { success: true };
    };
    return {
        renderError,
        showLoading,
        hideLoading,
        isValidUser,
    };
})();
