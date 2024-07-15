import { Car as TCar } from "../api/car/Car";

export const CAR_TITLE_FIELD = "licenseNumber";

export const CarTitle = (record: TCar): string => {
  return record.licenseNumber?.toString() || String(record.id);
};
