import { Salesperson as TSalesperson } from "../api/salesperson/Salesperson";

export const SALESPERSON_TITLE_FIELD = "lastName";

export const SalespersonTitle = (record: TSalesperson): string => {
  return record.lastName?.toString() || String(record.id);
};
