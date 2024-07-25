import { Product } from "../product/Product";
import { Order } from "../order/Order";

export type OrderItem = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  quantity: number | null;
  product?: Product | null;
  order?: Order | null;
};
