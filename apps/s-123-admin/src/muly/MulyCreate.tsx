import * as React from "react";
import { Create, SimpleForm, CreateProps, TextInput } from "react-admin";

export const MulyCreate = (props: CreateProps): React.ReactElement => {
  return (
    <Create {...props}>
      <SimpleForm>
        <TextInput label="Fld1" source="fld1" />
        <TextInput label="Fld2" source="fld2" />
      </SimpleForm>
    </Create>
  );
};
