import { SortOrder } from "../../util/SortOrder";

export type OrderOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  orderDate?: SortOrder;
  status?: SortOrder;
  products?: SortOrder;
  customerId?: SortOrder;
};
