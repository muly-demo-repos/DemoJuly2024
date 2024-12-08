import { Sale as TSale } from "../api/sale/Sale";

export const SALE_TITLE_FIELD = "id";

export const SaleTitle = (record: TSale): string => {
  return record.id?.toString() || String(record.id);
};
