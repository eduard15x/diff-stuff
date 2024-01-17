import { FieldErrors, useForm, } from "react-hook-form"
import { DevTool } from "@hookform/devtools";
import { useEffect } from "react";


type FormValues = {
    username: string;
    email: string;
    channel: string;
    age: number;
    date: Date;
}

const TestForm = () => {
    // VARIANT I - empty form
    const form = useForm<FormValues>();


    // VARIANT II - predefault setted form
    // const form = useForm({
    //     defaultValues: {
    //         username: 'string',
    //         email: 'email',
    //         channel: 'channel habra',
    //         age: 25,
    //         date: new Date()
    //     }
    // });


    // VARIANT III - predefault setted form after data fetched
    // const form = useForm<FormValues>({
    //     defaultValues: async () => {
    //         const res = await fetch('user/1');
    //         const data = await res.json();
    //         return {
    //             username: data.user,
    //             email: data.email,
    //             channel: data.channel
    //         };
    //     }
    // });
    const { register, control, handleSubmit, formState, watch, getValues, reset } = form
    const { errors, isDirty, isValid, isSubmitting, isSubmitted, isSubmitSuccessful } = formState;
    // const { name, ref, onChange, onBlur } = register("username") -> under the hood

    console.log({isDirty, isValid})
    console.log({isSubmitting, isSubmitted, isSubmitSuccessful})

    const onSubmit = (data: FormValues) => {
        console.log('form submit')
        console.log(data)
        console.log(formState)
        console.log(errors)
    }

    const onError = (errors: FieldErrors<FormValues>) => {
        console.log(errors);
    }

    const usernameWatch = watch('username');

    const getValuesWithoutSubmit = () => {
        console.log(getValues());
    }

    const handleResetForm = () => {
        reset()
    }

    useEffect(() => {
        if (isSubmitSuccessful) {
            reset()
        }
    }, [])

  return (
    <div>
        <h2>Username is: { usernameWatch }</h2>
        <form onSubmit={handleSubmit(onSubmit, onError)} noValidate>
            


            <label htmlFor="username">Username</label>
            {/* under the hood */}
            {/* <input type="text" id="username" name={name} ref={ref} onChange={onChange} onBlur={onBlur} /> */}
            <input type="text" id="username" {...register('username', {required: 'Username is required'})} />
            <p className="error">{ errors.username?.message }</p>



            <label htmlFor="email">Email</label>
            <input type="text" id="email" {...register('email', {
                pattern: {
                    value: /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/,
                    message: 'Invalid email format'
                },
                validate: {
                    notAdmin: (fieldValue) => {
                        return fieldValue !== "admin@example.com" || "Enter a different email address"
                    },
                    notBlackListed: (fieldValue) => {
                        return !fieldValue.endsWith("typeless.ai") || "This domain is not supported"
                    },
                    // emailAvailable: async (fieldValue) => {
                    //     const res = await fetch('users/email=fieldvalue')
                    //     const data = await res.json()

                    //     return data.length = 0 || 'Email already exist'
                    // }
                }
            })} />
            <p className="error">{ errors.email?.message }</p>



            <label htmlFor="channel">Channel</label>
            <input type="text" id="channel" {...register('channel')} />
            <p className="error">{ errors.channel?.message }</p>



            <label htmlFor="age">Age</label>
            <input type="number" id="age" {...register('age', {
                valueAsNumber: true,
                required: {
                    value: true,
                    message: 'Age is required'
                }
            })} />
            <p className="error">{ errors.age?.message }</p>





            <label htmlFor="date">Date of birth</label>
            <input type="date" id="date" {...register('date', {
                valueAsDate: true,
                required: {
                    value: true,
                    message: 'Date of birth is required'
                }
            })} />
            <p className="error">{ errors.date?.message }</p>


            <button disabled={!isDirty || !isValid || isSubmitting  }>
                Submit
            </button>

            <button onClick={getValuesWithoutSubmit}>
                Check values
            </button>

            <button onClick={handleResetForm}>
                Reset form
            </button>
        </form>
        <DevTool control={control} />
    </div>
  )
}

export default TestForm