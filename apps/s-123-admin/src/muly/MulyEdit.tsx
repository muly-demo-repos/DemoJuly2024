import * as React from "react";
import { Edit, SimpleForm, EditProps, TextInput } from "react-admin";

export const MulyEdit = (props: EditProps): React.ReactElement => {
  return (
    <Edit {...props}>
      <SimpleForm>
        <TextInput label="Fld1" source="fld1" />
        <TextInput label="Fld2" source="fld2" />
      </SimpleForm>
    </Edit>
  );
};
