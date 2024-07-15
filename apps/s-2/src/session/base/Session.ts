/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import { ObjectType, Field } from "@nestjs/graphql";
import { ApiProperty } from "@nestjs/swagger";
import {
  IsString,
  MaxLength,
  IsDate,
  ValidateNested,
  IsOptional,
} from "class-validator";
import { Type } from "class-transformer";
import { User } from "../../user/base/User";

@ObjectType()
class Session {
  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @Field(() => String)
  id!: string;

  @ApiProperty({
    required: true,
    type: String,
  })
  @IsString()
  @MaxLength(256)
  @Field(() => String)
  sessionToken!: string;

  @ApiProperty({
    required: true,
  })
  @IsDate()
  @Type(() => Date)
  @Field(() => Date)
  expires!: Date;

  @ApiProperty({
    required: false,
    type: () => User,
  })
  @ValidateNested()
  @Type(() => User)
  @IsOptional()
  user?: User | null;
}

export { Session as Session };
