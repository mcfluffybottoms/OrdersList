const API_URL = import.meta.env.VITE_API_URL;

export type Address = {
    locality: string;
    streetAddress: string
}

export type Order = {
    id: number;
    senderAddress: Address;
    receiverAddress: Address;
    weight: number;
    pickupDate: Date
}

export type CreateOrderRequest = {
    senderAddress: Address;
    receiverAddress: Address;
    weight: number;
    pickupDate: Date
}

export async function createOrder(order: CreateOrderRequest) {
    const response = await fetch(`${API_URL}/create`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(order),
    });
    if (!response.ok) {
        throw new Error(
            `Failed to create order: ${response.status} ${response.statusText}`
        );
    }
    return response;
}

export async function getAllOrders() {
    const response = await fetch(`${API_URL}`);
    if (!response.ok) {
        throw new Error(
            `Failed to fetch orders: ${response.status} ${response.statusText}`
        );
    }
    return response.json();
}

export async function getOrder(id: number) {
    const response = await fetch(`${API_URL}/${id}`);
    if (!response.ok) {
        throw new Error(
            `Failed to fetch order: ${response.status} ${response.statusText}`
        );
    }
    return response.json();
}