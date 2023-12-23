import request from "@/store/request";

const technology = {
    namespaced: true,
    actions: {
        async GET(context, query){
            const data = await request(context, "/technology/"+query, "GET")
            return data
        },
        async POST(context, body){
            const data = await request(context, "/technology/", "POST", body)
            return data
        },
        async DELETE(context, id){
            const data = await request(context, "/technology/"+id, "DELETE")
            return data
        },
        async PUT(context, body){
            const data = await request(context, "/technology/"+body.id, "PUT", body.form)
            return data
        },
    }
}

export default technology