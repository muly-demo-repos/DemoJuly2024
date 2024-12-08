import { Car as TCar } from "../api/car/Car";

export const CAR_TITLE_FIELD = "make";

export const CarTitle = (record: TCar): string => {
  return record.make?.toString() || String(record.id);
};
