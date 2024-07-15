import { Sale as TSale } from "../api/sale/Sale";

export const SALE_TITLE_FIELD = "client";

export const SaleTitle = (record: TSale): string => {
  return record.client?.toString() || String(record.id);
};
