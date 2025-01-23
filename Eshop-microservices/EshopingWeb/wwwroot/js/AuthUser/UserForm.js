//import { UserModel } from './UserModel.js';
const UserForm = (() => {
    const init = () => {
        const form = document.querySelector('#user-form');
        const firstNameInput = document.querySelector('#first-name');
        const lastNameInput = document.querySelector('#last-name');
        const emailInput = document.querySelector('#email');
        const messageContainer = document.querySelector('#form-message');

        form.addEventListener('submit', (event) => {
            event.preventDefault();

            const user = {
                Username: firstNameInput.value.trim(),
                FullName: lastNameInput.value.trim(),
                Email: emailInput.value.trim()
            };

            const validation = Common.isValidUser(user);
            if (!validation.success) {
                messageContainer.textContent = validation.message;
                messageContainer.className = 'text-danger';
                return;
            }

            AjaxHelper.post('/Auth/CreateUser', JSON.stringify(user), {
                'Content-Type': 'application/json',
            })
                .then((response) => {
                    if (response.success) {
                        messageContainer.textContent = 'User added successfully!';
                        messageContainer.className = 'text-success';
                        form.reset();
                    } else {
                        messageContainer.textContent = response.message;
                        messageContainer.className = 'text-danger';
                    }
                })
                .catch(({ xhr, status, error }) => {
                    messageContainer.textContent = 'Error submitting form.';
                    messageContainer.className = 'text-danger';
                    console.error('Error:', status, error);
                });

        });
    };

    return { init };
})();
