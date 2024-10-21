
document.addEventListener("DOMContentLoaded", function () {
    console.log("Document is ready!");

    // Search filter for the contact list
    const searchInput = document.getElementById('searchInput');
    const contactRows = document.querySelectorAll('.contact-row');

    searchInput.addEventListener('input', function () {
        const filter = searchInput.value.toLowerCase();
        contactRows.forEach(row => {
            const text = row.textContent.toLowerCase();
            row.style.display = text.includes(filter) ? '' : 'none';
        });
    });

    // Modal functionality for delete confirmation
    const deleteButtons = document.querySelectorAll('.btn-danger');
    const modal = document.getElementById('deleteModal');
    const confirmDeleteButton = document.getElementById('confirmDeleteButton');

    deleteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            const contactName = event.target.closest('tr').querySelector('td:first-child').textContent;
            const contactId = event.target.getAttribute('data-id');

            // Show modal with the contact name
            modal.querySelector('.modal-body').textContent = `Are you sure you want to delete ${contactName}?`;
            modal.setAttribute('data-id', contactId);
            $(modal).modal('show');
        });
    });

    confirmDeleteButton.addEventListener('click', function () {
        const contactId = modal.getAttribute('data-id');
        // Redirect to the delete action
        window.location.href = `/Contact/Delete/${contactId}`;
    });
});
