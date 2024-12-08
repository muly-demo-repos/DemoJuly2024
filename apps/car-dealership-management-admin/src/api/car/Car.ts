import { Sale } from "../sale/Sale";

export type Car = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  make: string | null;
  year: number | null;
  model: string;
  sales?: Array<Sale>;
  price: number | null;
  licenseNumber: string | null;
};
