import { Salesperson as TSalesperson } from "../api/salesperson/Salesperson";

export const SALESPERSON_TITLE_FIELD = "name";

export const SalespersonTitle = (record: TSalesperson): string => {
  return record.name?.toString() || String(record.id);
};
