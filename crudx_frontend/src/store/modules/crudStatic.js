import request from "@/store/request";

const crudStatic = {
    namespaced: true,
    actions: {
        async GET(context, query){
            const data = await request(context, "/crudStatic/"+query, "GET")
            return data
        },
        async POST(context, body){
            const data = await request(context, "/crudStatic/", "POST", body)
            return data
        },
        async DELETE(context, id){
            const data = await request(context, "/crudStatic/"+id, "DELETE")
            return data
        },
        async PUT(context, body){
            const data = await request(context, "/crudStatic/"+body.id, "PUT", body.form)
            return data
        },
    }
}

export default crudStatic