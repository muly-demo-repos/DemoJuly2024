import * as React from "react";

import {
  Create,
  SimpleForm,
  CreateProps,
  DateTimeInput,
  NumberInput,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { SalespersonTitle } from "../salesperson/SalespersonTitle";

export const SaleCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <DateTimeInput label="date" source="date" />
        <NumberInput label="amount" source="amount" />
        <TextInput label="client" source="client" />
        <ReferenceInput
          source="salesperson.id"
          reference="Salesperson"
          label="salesperson"
        >
          <SelectInput optionText={SalespersonTitle} />
        </ReferenceInput>
        <TextInput label="vehicle" source="vehicle" />
      </SimpleForm>
    </Create>
  );
};
