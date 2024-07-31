import Card from "antd/es/card/Card"
import { CardTitle } from "./Cardtitle"
import Button from "antd/es/button/button"

interface Props {
    products: Product[];
    handleDelete: (id: string) => void;
    handleOpen: (product : Product) => void;
}

export const Products = ({products, handleDelete, handleOpen}: Props) => {
    return (
        <div className="cards">
            {products.map((product : Product) => (
                <Card 
                key={product.id} 
                title={<CardTitle title={product.title} price={product.price}/>} 
                bordered={false}>
                    <p>{product.description}</p>
                    <div className="card_buttons">
                        <Button onClick={() => handleOpen(product)} style={{ flex: 1 }}>Edit</Button>
                        <Button onClick={() => handleDelete(product.id)} danger style={{ flex: 1 }}>Delete</Button>
                    </div>
                </Card>
            ))}
        </div>
    )
}