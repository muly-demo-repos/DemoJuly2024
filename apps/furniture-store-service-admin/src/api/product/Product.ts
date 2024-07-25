import { OrderItem } from "../orderItem/OrderItem";

export type Product = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  stock: number | null;
  name: string | null;
  description: string | null;
  price: number | null;
  orderItems?: Array<OrderItem>;
};
