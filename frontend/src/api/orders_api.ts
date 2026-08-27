const API_URL = `https://localhost:5050/orders`;

type address = {
    locality: string;
    streetAddress: string
}

type order = {
    id: number;
    senderAddress: address;
    receiverAddress: address;
    weight: number;
    pickupDate: Date
}

export async function createOrder(order: order) {
    const response = await fetch(`${API_URL}/create`, {
        method: "POST",
        headers: {
        "Content-Type": "application/json",
        },
        body: JSON.stringify(order),
    });
    if (!response.ok) {
        throw new Error("Failed to create order");
    }
    return response;
}

export async function getAllOrders() {
    const response = await fetch(`${API_URL}`);
    if (!response.ok) {
        throw new Error("Failed to fetch orders");
    }
    return response.json();
}

export async function getOrder(id: number) {
    const response = await fetch(`${API_URL}/${id}`);
    if (!response.ok) {
        throw new Error("Failed to fetch order");
    }
    return response.json();
}