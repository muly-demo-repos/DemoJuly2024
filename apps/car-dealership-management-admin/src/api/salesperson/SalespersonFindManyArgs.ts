import { SalespersonWhereInput } from "./SalespersonWhereInput";
import { SalespersonOrderByInput } from "./SalespersonOrderByInput";

export type SalespersonFindManyArgs = {
  where?: SalespersonWhereInput;
  orderBy?: Array<SalespersonOrderByInput>;
  skip?: number;
  take?: number;
};
