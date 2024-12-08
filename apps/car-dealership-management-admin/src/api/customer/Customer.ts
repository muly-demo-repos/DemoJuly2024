import { Sale } from "../sale/Sale";

export type Customer = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  name: string | null;
  email: string | null;
  phone: string | null;
  address: string | null;
  sales?: Array<Sale>;
};
