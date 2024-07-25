import { SortOrder } from "../../util/SortOrder";

export type OrderItemOrderByInput = {
  id?: SortOrder;
  createdAt?: SortOrder;
  updatedAt?: SortOrder;
  quantity?: SortOrder;
  productId?: SortOrder;
  orderId?: SortOrder;
};
