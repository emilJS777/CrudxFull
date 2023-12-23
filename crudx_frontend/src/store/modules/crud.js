import request from "@/store/request";

const crud = {
    namespaced: true,
    actions: {
        async GET(context, query){
            const data = await request(context, "/crud/"+query, "GET")
            return data
        },
        async POST(context, body){
            const data = await request(context, "/crud/", "POST", body)
            return data
        },
        async DELETE(context, id){
            const data = await request(context, "/crud/"+id, "DELETE")
            return data
        },
        async PUT(context, body){
            const data = await request(context, "/crud/"+body.id, "PUT", body.form)
            return data
        },
    }
}

export default crud