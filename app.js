const API_URL = 'http://localhost:5000/api/inventory';

async function fetchInventoryItems() {
    try {
        const response = await fetch(API_URL);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        renderInventoryTable(data);
    } catch (error) {
        console.error('Error fetching inventory:', error);
    }
}

function renderInventoryTable(items) {
    const tableBody = document.getElementById('inventory-body');
    if (!tableBody) return;
    tableBody.innerHTML = '';
    
    items.forEach(item => {
        const row = `<tr>
            <td>${item.id}</td>
            <td>${item.name}</td>
            <td>${item.quantity}</td>
            <td>$${item.price.toFixed(2)}</td>
        </tr>`;
        tableBody.innerHTML += row;
    });
}
