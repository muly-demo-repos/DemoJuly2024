import { Car } from "../car/Car";

export type Customer = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  name: string | null;
  lastName: string | null;
  cars?: Array<Car>;
};
