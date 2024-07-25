import { SaleWhereInput } from "./SaleWhereInput";
import { SaleOrderByInput } from "./SaleOrderByInput";

export type SaleFindManyArgs = {
  where?: SaleWhereInput;
  orderBy?: Array<SaleOrderByInput>;
  skip?: number;
  take?: number;
};
