import Modal from "antd/es/modal/Modal";
import { ProductRequest } from "../services/products";
import Input from "antd/es/input/Input";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props{
    mode: Mode;
    values: Product;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: ProductRequest) => void;
    handleUpdate: (id: string, request: ProductRequest) => void;
}

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateProduct = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const [title, setTitle] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [price, setPrice] = useState<number>(1);
    const [filename, setFilename] = useState<string>("");

    useEffect(() => {
        setTitle(values.title);
        setDescription(values.description);
        setPrice(values.price);
        setFilename(values.filename);
    }, [values]);

    const handleOnOk = async () => {
        const productRequest = {title, description, price, filename};

        mode == Mode.Create ? handleCreate(productRequest) : handleUpdate(values.id,productRequest);
    }

    return (
        <Modal title={mode === Mode.Create ? "Добавить книгу" : "Редактировать книгу"} 
            open={isModalOpen} 
            onOk={handleOnOk} 
            onCancel={handleCancel} 
            cancleText={"Отмена"}>

            <div className="product_modal">
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Название"    
                />
                <TextArea
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    autoSize={{minRows: 3, maxRows:3}}
                    placeholder="Описание"
                />
                <Input
                    value={filename}
                    onChange={(e) => setFilename(e.target.value)}
                    placeholder="Ссылка на изображение"
                />
                <Input
                    value={price}
                    onChange={(e) => setPrice(Number(e.target.value))}
                    placeholder="Цена"
                />
            </div>
        </Modal>
    )
};