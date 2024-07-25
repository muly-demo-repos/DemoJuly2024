import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  DateTimeInput,
  NumberInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { CarTitle } from "../car/CarTitle";
import { CustomerTitle } from "../customer/CustomerTitle";
import { SalespersonTitle } from "../salesperson/SalespersonTitle";

export const SaleEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <DateTimeInput label="date" source="date" />
        <NumberInput label="totalPrice" source="totalPrice" />
        <ReferenceInput source="car.id" reference="Car" label="Car">
          <SelectInput optionText={CarTitle} />
        </ReferenceInput>
        <ReferenceInput
          source="customer.id"
          reference="Customer"
          label="Customer"
        >
          <SelectInput optionText={CustomerTitle} />
        </ReferenceInput>
        <ReferenceInput
          source="salesperson.id"
          reference="Salesperson"
          label="Salesperson"
        >
          <SelectInput optionText={SalespersonTitle} />
        </ReferenceInput>
      </SimpleForm>
    </Edit>
  );
};
