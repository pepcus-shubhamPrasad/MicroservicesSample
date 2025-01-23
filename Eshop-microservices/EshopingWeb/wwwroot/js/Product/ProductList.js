const ProductList = (() => {

    // Fetch ProductList
    const fetchProductList = () => {
        return $.getJSON('/Product/ProductList');
    };

    // RenderTable
    const renderProductTable = (products) => {
        let html = `<table class="table table-striped table-bordered">
                <thead class="table-light">
                    <tr>
                        <th>Product Name</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>`;

        products.forEach(product => {
            html += `<tr>
                    <td>${product.productName}</td>
                    <td>$${product.productPrice}</td>
                </tr>`;
        });

        html += `</tbody>
            </table>`;

        $('#product-list').html(html);
    };

    const init = () => {
        const selector = '#product-list';
        Common.showLoading(selector);

        fetchProductList()
            .then(response => {
                Common.hideLoading(selector);

                if (response.success) {
                    renderProductTable(response.data.data);
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
