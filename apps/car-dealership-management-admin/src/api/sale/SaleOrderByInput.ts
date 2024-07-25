import { SortOrder } from "../../util/SortOrder";

export type SaleOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  date?: SortOrder;
  totalPrice?: SortOrder;
  carId?: SortOrder;
  customerId?: SortOrder;
  salespersonId?: SortOrder;
};
