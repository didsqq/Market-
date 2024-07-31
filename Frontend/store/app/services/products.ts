export interface ProductRequest {
    title: string;
    description: string;
    price: number;
}

export const getAllProducts = async () => {
    const response = await fetch("http://localhost:5078/Products");

    return response.json();
};

export const createProduct = async (productRequest: ProductRequest) => {
    await fetch("http://localhost:5078/Products",{
        method: "POST",
        headers:{
            "content-type": "application/json",
        },
        body: JSON.stringify(productRequest),
    });
};

export const updateProduct = async (id: string, productRequest: ProductRequest) => {
    await fetch(`http://localhost:5078/Products/${id}`,{
        method: "PUT",
        headers:{
            "content-type": "application/json",
        },
        body: JSON.stringify(productRequest),
    });
}

export const deleteProduct = async (id: string) => {
    await fetch(`http://localhost:5078/Products/${id}`,{
        method: "DELETE",
    });
}