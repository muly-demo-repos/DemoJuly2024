import * as React from "react";

import {
  Edit,
  SimpleForm,
  EditProps,
  DateTimeInput,
  NumberInput,
  TextInput,
  ReferenceInput,
  SelectInput,
} from "react-admin";

import { SalespersonTitle } from "../salesperson/SalespersonTitle";

export const SaleEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
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
    </Edit>
  );
};
