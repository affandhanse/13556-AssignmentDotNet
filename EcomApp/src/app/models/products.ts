export interface Products {
    id: number;
    name: string;
    description: string;
    price: number;
    pictureUrl: string;
    stock: number;
    categoryId: number;
    category?: Category;
}

export interface Category {
    name: string;
    description: string;
    id: number;
}

