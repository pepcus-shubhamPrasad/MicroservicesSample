const UserList = (() => {

    // Fetch userList
    const fetchUserList = () => {
        return $.getJSON('/Auth/GetUserList');
    };

    // RenderTable
    const renderUserTable = (users) => {
        let html = `<table class="table table-striped table-bordered">
                <thead class="table-light">
                    <tr>
                        <th>UserName</th>
                        <th>Email</th>
                    </tr>
                </thead>
                <tbody>`;

        users.forEach(users => {
            html += `<tr>
                    <td>${users.username}</td>
                    <td>${users.email}</td>
                </tr>`;
        });

        html += `</tbody>
            </table>`;

        $('#user-list').html(html);
    };

    const init = () => {
        const selector = '#user-list';
        Common.showLoading(selector);

        fetchUserList()
            .then(response => {
                Common.hideLoading(selector);

                if (response.success) {
                    renderUserTable(response.data);
                } else {
                    Common.renderError(selector, response.message);
                }
            })
            .catch(() => {
                Common.hideLoading(selector);
                Common.renderError(selector, 'Error loading data.');
            });
    };

    return { init };
})();
