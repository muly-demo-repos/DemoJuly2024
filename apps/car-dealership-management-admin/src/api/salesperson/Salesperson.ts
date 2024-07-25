import { Sale } from "../sale/Sale";

export type Salesperson = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  name: string | null;
  email: string | null;
  phone: string | null;
  sales?: Array<Sale>;
};
