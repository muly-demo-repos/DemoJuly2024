import * as React from "react";
import {
  Show,
  SimpleShowLayout,
  ShowProps,
  TextField,
  DateField,
  ReferenceField,
} from "react-admin";
import { CAR_TITLE_FIELD } from "../car/CarTitle";
import { CUSTOMER_TITLE_FIELD } from "../customer/CustomerTitle";
import { SALESPERSON_TITLE_FIELD } from "../salesperson/SalespersonTitle";

export const SaleShow = (props: ShowProps): React.ReactElement => {
  return (
    <Show {...props}>
      <SimpleShowLayout>
        <TextField label="ID" source="id" />
        <DateField source="createdAt" label="Created At" />
        <DateField source="updatedAt" label="Updated At" />
        <TextField label="date" source="date" />
        <TextField label="totalPrice" source="totalPrice" />
        <ReferenceField label="Car" source="car.id" reference="Car">
          <TextField source={CAR_TITLE_FIELD} />
        </ReferenceField>
        <ReferenceField
          label="Customer"
          source="customer.id"
          reference="Customer"
        >
          <TextField source={CUSTOMER_TITLE_FIELD} />
        </ReferenceField>
        <ReferenceField
          label="Salesperson"
          source="salesperson.id"
          reference="Salesperson"
        >
          <TextField source={SALESPERSON_TITLE_FIELD} />
        </ReferenceField>
      </SimpleShowLayout>
    </Show>
  );
};
