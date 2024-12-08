import { CarWhereUniqueInput } from "../car/CarWhereUniqueInput";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { SalespersonWhereUniqueInput } from "../salesperson/SalespersonWhereUniqueInput";

export type SaleUpdateInput = {
  date?: Date | null;
  totalPrice?: number | null;
  car?: CarWhereUniqueInput | null;
  customer?: CustomerWhereUniqueInput | null;
  salesperson?: SalespersonWhereUniqueInput | null;
};
