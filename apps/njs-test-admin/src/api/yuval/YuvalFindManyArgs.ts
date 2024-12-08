import { YuvalWhereInput } from "./YuvalWhereInput";
import { YuvalOrderByInput } from "./YuvalOrderByInput";

export type YuvalFindManyArgs = {
  where?: YuvalWhereInput;
  orderBy?: Array<YuvalOrderByInput>;
  skip?: number;
  take?: number;
};
